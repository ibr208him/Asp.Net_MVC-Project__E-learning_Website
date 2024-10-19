namespace e_learning.PL.Helpers
{
    public class FilesSetting
    {
        public static string UploadFile(IFormFile file, string folderName)
        {

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            string fileName = $" {Guid.NewGuid()}{file.FileName} "; // to avoid conflict of douplicated files
            string filePath = Path.Combine(folderPath, fileName); // filePath is the path to be stored inside the database
                                                                  //var fileStream = new FileStream(filePath, FileMode.Create);
                                                                  //file.CopyTo(fileStream);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);  // The using block ensures fileStream is closed after the operation.
            }

            return fileName;
        }

        public static void DeleteFile( string fileName,string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName,fileName);
            if(File.Exists(filePath) )
            {
                File.Delete(filePath);
            }
        }

    }
}

                //string mainFolderPath = "D:\\أكاديمية المعرفة\\Full stack\\Backend\\ASP.net__round9\\Mine\\#7 MVC\\My MVC Project\\MVC Project_IbrahimMaali\\e-learning\\e-learning.PL\\wwwroot\\files\\images\\";


// string folderPath =mainFolderPath+ folderName;//folder name to store in which will be created inside the
// main folder path

//string folderPath = Directory.GetCurrentDirectory() + "\\wwwroot\\files\\"+folderName;