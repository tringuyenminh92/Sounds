using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AudioRecord.Controllers
{
    public class SampleController : Controller
    {
        //
        // GET: /Sample/

        public ActionResult Index()
        {
            return View();
        }

        // ---/RecordRTC/PostRecordedAudioVideo
        [HttpPost]
        public ActionResult PostRecordedAudio()
        {
            foreach (string upload in Request.Files)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "/uploads/";
                var file = Request.Files[upload];
                if (file == null) continue;

                file.SaveAs(Path.Combine(path, Request.Form[0]));
            }
            return Json(Request.Form[0]);
        }

        // ---/RecordRTC/DeleteFile
        [HttpPost]
        public ActionResult DeleteFile()
        {
            var fileUrl = AppDomain.CurrentDomain.BaseDirectory + "/uploads/" + Request.Form["delete-file"];
            new FileInfo(fileUrl + ".wav").Delete();
            new FileInfo(fileUrl + ".ogg").Delete();
            new FileInfo(fileUrl + ".webm").Delete();
            return Json(true);
        }
    }
}
