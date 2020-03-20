using AspNetCoreIdentityCustomization.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreIdentityCustomization.Data
{
    interface IPosLogRepository
    {
        IEnumerable<PostLog> GetPostLog(int PostLogId);
        IEnumerable<PostLog> GetPostLogList();

        PostLog GetOnePostLog(int PostLogId);


        //PostLog AddPostLog(PostLog postLog);
        //IEnumerable<PostLog> GetListPostLog();
        //PostLog UpdatePostLog(PostLog postlog);
        //PostLog DeletePostLog(int PostLogId);

    }
}
