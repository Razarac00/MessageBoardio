using System;
using System.Collections.Generic;

namespace MessageBoardio.MVC.Models
{
    public sealed class MessageBoardModel
    {
        
        // public string RequestId { get; set; }

        // public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        private static MessageBoardModel instance = null;
        private static readonly object padlock = new object();

        private static List<string> messages = new List<string> {};

        MessageBoardModel() {}

        public static MessageBoardModel Instance // doesn't need to be manually setup as singleton; useSingleton does that for us
        { 
            get 
            {
                lock (padlock)
                {
                    if (instance == null) 
                    { 
                        instance = new MessageBoardModel(); 
                    }
                }
                return instance;
            }
        }

        public void Add(string input)
        {
            messages.Add(input);
        }

        public List<string> ListAll()
        {
            return messages;
        }

    }
}