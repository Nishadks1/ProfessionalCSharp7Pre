using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Input.Inking.Analysis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InkSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private InkAnalyzer _inkAnalyzer;
        public MainPage()
        {
            this.InitializeComponent();
            inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
            _inkAnalyzer = new InkAnalyzer();
            inkCanvas.InkPresenter.StrokesCollected += InkPresenter_StrokesCollected;
            inkCanvas.InkPresenter.StrokesErased += InkPresenter_StrokesErased;

        }

        private void InkPresenter_StrokesErased(InkPresenter sender, InkStrokesErasedEventArgs args)
        {
            foreach (var stroke in args.Strokes)
            {
                _inkAnalyzer.RemoveDataForStroke(stroke.Id);
            }

        }

        private void InkPresenter_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
        {
            _inkAnalyzer.AddDataForStrokes(args.Strokes);
        }

        private async void OnAnalyze()
        {
            InkAnalysisResult result = await _inkAnalyzer.AnalyzeAsync();
            IReadOnlyList<IInkAnalysisNode> drawings = _inkAnalyzer.AnalysisRoot.FindNodes(InkAnalysisNodeKind.InkDrawing);
            foreach (var drawing in drawings)
            { 
                if (drawing is InkAnalysisInkDrawing shape)
                {
                    if (shape.DrawingKind == InkAnalysisDrawingKind.Drawing)
                    {
                        continue;
                    }

                    if (shape.DrawingKind == InkAnalysisDrawingKind.Circle || shape.DrawingKind == InkAnalysisDrawingKind.Ellipse)
                    {
                        AddEllipseToCanvas(shape);
                        AddDimensions(shape);
                    }                 
                }
            }

            drawings = _inkAnalyzer.AnalysisRoot.FindNodes(InkAnalysisNodeKind.Line);
            foreach (var node in drawings)
            {
                if (node is InkAnalysisLine line)
                {

                }
            }
        }

        private void AddDimensions(InkAnalysisInkDrawing shape)
        {
            var points = shape.Points;
            var line1 = new Line { X1 = points[0].X, Y1 = points[0].Y, X2 = points[1].X, Y2 = points[1].Y };
            canvas.Children.Add(line1);
            var line2 = new Line { X1 = points[1].X, Y1 = points[1].Y, X2 = points[2].X, Y2 = points[2].Y };
            canvas.Children.Add(line2);
            var line3 = new Line { X1 = points[2].X, Y1 = points[2].Y, X2 = points[3].X, Y2 = points[3].Y };
            canvas.Children.Add(line3);
            var line4 = new Line { X1 = points[3].X, Y1 = points[3].Y, X2 = points[0].X, Y2 = points[0].Y };
            canvas.Children.Add(line4);
        }

        static double Distance(Point p0, Point p1)
        {
            double dx = p1.X - p0.X;
            double dy = p1.Y - p0.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void AddEllipseToCanvas(InkAnalysisInkDrawing shape)
        {
            var ellipse = new Ellipse();
            IReadOnlyList<Point> points = shape.Points;
            var center = new Point((points[0].X + points[2].X) / 2.0, (points[0].Y + points[2].Y) / 2.0);
            ellipse.Width = Distance(points[0], points[2]);
            var compositeTransform = new CompositeTransform();
            if (shape.DrawingKind == InkAnalysisDrawingKind.Circle)
            {
                ellipse.Height = ellipse.Width;
            }
            else
            {
                ellipse.Height = Distance(points[1], points[3]);

                double rotationAngle = Math.Atan2(points[2].Y - points[0].Y, points[2].X - points[0].X);

                compositeTransform.Rotation = rotationAngle * 180 / Math.PI;
                compositeTransform.CenterX = ellipse.Width / 2.0;
                compositeTransform.CenterY = ellipse.Height / 2.0;
            }

            compositeTransform.TranslateX = center.X - ellipse.Width / 2.0;
            compositeTransform.TranslateY = center.Y - ellipse.Height / 2.0;

            ellipse.RenderTransform = compositeTransform;
            canvas.Children.Add(ellipse);
        }

        private const string FileTypeExtension = ".strokes";
        public async void OnSave()
        {
            var picker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                DefaultFileExtension = FileTypeExtension,
                SuggestedFileName = "sample"
            };
            picker.FileTypeChoices.Add("Stroke File", new List<string>() { FileTypeExtension });
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                using (StorageStreamTransaction tx = await file.OpenTransactedWriteAsync())
                {
                    await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(tx.Stream);
                    await tx.CommitAsync();
                }
            }
        }

        public async void OnLoad()
        {
            var picker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            picker.FileTypeFilter.Add(FileTypeExtension);

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    await inkCanvas.InkPresenter.StrokeContainer.LoadAsync(stream);
                }
            }
        }

        public void OnClear()
        {
            inkCanvas.InkPresenter.StrokeContainer.Clear();
            canvas.Children.Clear();
        }
    }
}
