using Hiring.Models;

namespace Hiring.Services
{
    public class CvService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public CvService(IWebHostEnvironment environment, AppDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public async Task<CV> uploadCv(UploadCv cv)
        {
            var newCv= new CV();
            if (cv.File != null || cv.File.Length > 0)
            {
                //throw new ArgumentException("file is not found");
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "cvs/");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, cv.File.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    cv.File.CopyTo(stream);
                }
                newCv.filePath = filePath;
                newCv.fileName = cv.File.FileName;
            }
            return newCv;
        }
    }
}
