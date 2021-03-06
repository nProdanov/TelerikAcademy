﻿using System;

namespace SocialNetwork.Client.XmlModels
{
    [Serializable]
    public class XmlMessage
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }
    }
}