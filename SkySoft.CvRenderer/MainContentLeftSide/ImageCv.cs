﻿using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace WebApplicationPdf.MainContentLeftSide
{
    public static class ImageCv
    {
        //public Basics? basics { get; }
        //public ImageCv(Basics? value)
        //{
        //    basics = value;
        //}

        public static void ElementImage(IContainer container)
        {
            container
                .Layers(layer =>
                {
                    layer.PrimaryLayer()
                      .AlignRight()
                      .Height(170)
                      .Image(AssetsHelper.ReadResourceBytes("Assets/Images/RedPolygon.png"))
                      .FitArea();

                    //layer.Layer()
                    //.Padding(50)
                    //.AlignCenter()
                    //.Image(@"C:\WebApplicationPdf\WebApplicationPdf\Image\Photo.png");


                    //layer.Layer()
                    //.Canvas((canvas, size) =>
                    //{
                    //    using var paint = new SKPaint
                    //    {
                            
                    //    };

                    //    using var image = SKImage.FromEncodedData(@"C:\WebApplicationPdf\WebApplicationPdf\Image\Photo.png");

                    //    canvas.DrawImage(image, new SKPoint(0, 0));
                    //});

                });
        }
    }
}
