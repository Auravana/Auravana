using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using NLog;
using Auravana.Domain.Abstract;

namespace Auravana.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public void Send(string name, string message)
        {
            message = string.Format("{0} - {1}", DateTime.Now.ToShortTimeString(), message);
            Clients.All.addNewMessageToPage(name, message);
            log.Debug("{0} has sent: {1}", name, message);
        }
    }
}