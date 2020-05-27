using System;
using System.IO;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Pdfocr.Helpers;
using iText.Test;
using iText.Test.Attributes;

namespace iText.Pdfocr {
    public class PdfFontTest : ExtendedITextTest {
        [NUnit.Framework.Test]
        public virtual void TestFontColor() {
            String testName = "testFontColor";
            String path = PdfHelper.GetImagesTestDirectory() + "multipage.tiff";
            String pdfPath = PdfHelper.GetTargetDirectory() + testName + ".pdf";
            FileInfo file = new FileInfo(path);
            OcrPdfCreatorProperties properties = new OcrPdfCreatorProperties();
            properties.SetTextLayerName("Text1");
            Color color = DeviceCmyk.CYAN;
            properties.SetTextColor(color);
            PdfHelper.CreatePdf(pdfPath, file, properties);
            ExtractionStrategy strategy = PdfHelper.GetExtractionStrategy(pdfPath, "Text1");
            Color fillColor = strategy.GetFillColor();
            NUnit.Framework.Assert.AreEqual(color, fillColor);
        }

        [LogMessage(PdfOcrLogMessageConstant.CANNOT_READ_PROVIDED_FONT, Count = 1)]
        [NUnit.Framework.Test]
        public virtual void TestInvalidFont() {
            String testName = "testImageWithoutText";
            String path = PdfHelper.GetDefaultImagePath();
            String pdfPath = PdfHelper.GetTargetDirectory() + testName + ".pdf";
            FileInfo file = new FileInfo(path);
            OcrPdfCreatorProperties properties = new OcrPdfCreatorProperties();
            properties.SetFontPath("font.ttf");
            properties.SetScaleMode(ScaleMode.SCALE_TO_FIT);
            PdfHelper.CreatePdf(pdfPath, file, properties);
            String result = PdfHelper.GetTextFromPdfLayer(pdfPath, "Text Layer");
            NUnit.Framework.Assert.AreEqual(PdfHelper.DEFAULT_EXPECTED_RESULT, result);
            NUnit.Framework.Assert.AreEqual(ScaleMode.SCALE_TO_FIT, properties.GetScaleMode());
        }

        [NUnit.Framework.Test]
        public virtual void TestDefaultFontInPdfARgb() {
            String testName = "testDefaultFontInPdf";
            String path = PdfHelper.GetDefaultImagePath();
            String pdfPath = PdfHelper.GetTargetDirectory() + testName + ".pdf";
            FileInfo file = new FileInfo(path);
            PdfHelper.CreatePdfA(pdfPath, file, new OcrPdfCreatorProperties().SetTextColor(DeviceRgb.BLACK), PdfHelper
                .GetRGBPdfOutputIntent());
            ExtractionStrategy strategy = PdfHelper.GetExtractionStrategy(pdfPath);
            PdfFont font = strategy.GetPdfFont();
            String fontName = font.GetFontProgram().GetFontNames().GetFontName();
            NUnit.Framework.Assert.IsTrue(fontName.Contains("LiberationSans"));
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [LogMessage(iText.IO.IOException.TypeOfFontIsNotRecognized, Count = 1)]
        [NUnit.Framework.Test]
        public virtual void TestInvalidCustomFontInPdfACMYK() {
            String testName = "testInvalidCustomFontInPdf";
            String path = PdfHelper.GetDefaultImagePath();
            String pdfPath = PdfHelper.GetTargetDirectory() + testName + ".pdf";
            FileInfo file = new FileInfo(path);
            PdfHelper.CreatePdfA(pdfPath, file, new OcrPdfCreatorProperties().SetFontPath(path), PdfHelper.GetCMYKPdfOutputIntent
                ());
            ExtractionStrategy strategy = PdfHelper.GetExtractionStrategy(pdfPath);
            PdfFont font = strategy.GetPdfFont();
            String fontName = font.GetFontProgram().GetFontNames().GetFontName();
            NUnit.Framework.Assert.IsTrue(fontName.Contains("LiberationSans"));
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TestCustomFontInPdf() {
            String testName = "testDefaultFontInPdf";
            String path = PdfHelper.GetDefaultImagePath();
            String pdfPath = PdfHelper.GetTargetDirectory() + testName + ".pdf";
            FileInfo file = new FileInfo(path);
            PdfHelper.CreatePdfA(pdfPath, file, new OcrPdfCreatorProperties().SetFontPath(PdfHelper.GetFreeSansFontPath
                ()), PdfHelper.GetCMYKPdfOutputIntent());
            ExtractionStrategy strategy = PdfHelper.GetExtractionStrategy(pdfPath);
            PdfFont font = strategy.GetPdfFont();
            String fontName = font.GetFontProgram().GetFontNames().GetFontName();
            NUnit.Framework.Assert.IsTrue(fontName.Contains("FreeSans"));
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }
    }
}