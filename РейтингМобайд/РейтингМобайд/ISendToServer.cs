using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рейтинг
{
    interface ISendToServer
    {
        ServerStatusEnum goStatusNessage();

        ServerSendStruct goToServInfo();

        void sendServID(string id);


    }
}
