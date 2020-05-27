using System;

namespace iText.Pdfocr.Tesseract4 {
    public class Tesseract4LogMessageConstant {
        public const String TESSERACT_FAILED = "Tesseract failed: {0}";

        public const String CANNOT_READ_FILE = "Cannot read file {0}: {1}";

        public const String CANNOT_OCR_INPUT_FILE = "Cannot ocr input file: {1}";

        public const String CANNOT_USE_USER_WORDS = "Cannot use custom user words: {0}";

        public const String CANNOT_RETRIEVE_PAGES_FROM_IMAGE = "Cannot get pages from image {0}: {1}";

        public const String PAGE_NUMBER_IS_INCORRECT = "Provided number of page ({0}) is incorrect for {1}";

        public const String CANNOT_DELETE_FILE = "File {0} cannot be deleted: {1}";

        public const String CANNOT_PROCESS_IMAGE = "Cannot process " + "image: {0}";

        public const String READING_IMAGE_AS_PIX = "Trying to read image {0} as pix: {1}";

        public const String CANNOT_WRITE_TO_FILE = "Cannot write to file {0}: {1}";

        public const String CREATED_TEMPORARY_FILE = "Created temp file {0}";

        public const String CANNOT_CONVERT_IMAGE_TO_GRAYSCALE = "Cannot convert to gray image with depth {0}";

        public const String CANNOT_BINARIZE_IMAGE = "Cannot binarize image with depth {0}";

        public const String CANNOT_CREATE_BUFFERED_IMAGE = "Cannot create a buffered image from the input image: {0}";

        public const String START_OCR_FOR_IMAGES = "Starting ocr for {0} image(s)";

        public const String CANNOT_READ_INPUT_IMAGE = "Cannot read input image {0}";

        private Tesseract4LogMessageConstant() {
        }
    }
}