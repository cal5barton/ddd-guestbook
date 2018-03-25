using System;
using System.Collections.Generic;
using System.Text;

namespace DDDGuestbook.Core.Interfaces
{
    public interface IMessageSender
    {
        void SendGuestbookNotificationEmail(string toAddress, string messageBody);
    }
}
