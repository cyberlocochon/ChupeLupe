
using System;
using ChupeLupe.iOS.Renderes;
using ChupeLupe.Renderes;
using CoreAnimation;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
  [assembly: ExportRenderer(typeof(Gradiente), typeof(GradientColorStackRenderer))]

 namespace ChupeLupe.iOS.Renderes
{
    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            Gradiente stack = (Gradiente)this.Element;
            CGColor startColor = stack.StartColor.ToCGColor();

            CGColor endColor = stack.EndColor.ToCGColor();

            #region for Vertical Gradient

            var gradientLayer = new CAGradientLayer();

            #endregion

            #region for Horizontal Gradient

            //var gradientLayer = new CAGradientLayer()
            //{
            //  StartPoint = new CGPoint(0, 0.5),
            //  EndPoint = new CGPoint(1, 0.5)
            //};

            #endregion



            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor, endColor
        };

            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}