using System.Collections.Generic;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class Links
    {
        public List<string> Homepage { get; set; }
        public List<string> Blockchain_Site { get; set; }
        public List<string> Official_Forum_Url { get; set; }
        public List<string> Chat_Url { get; set; }
        public List<object> Announcement_Url { get; set; }
        public string Twitter_Screen_Name { get; set; }
        public string Facebook_Username { get; set; }
        public object Bitcointalk_Thread_Identifier { get; set; }
        public string Telegram_Channel_Identifier { get; set; }
        public string Subreddit_Url { get; set; }
    }
}
