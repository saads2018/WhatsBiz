using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASender
{
    public class WhatsAppHelper:WAPIHelper
    {
        public async Task waitVideo(IWebDriver driver, string number, string ImageBase64,string FileName)
        {
            SendAttachment(driver, number, ImageBase64, FileName, "");
        }
    }
}
