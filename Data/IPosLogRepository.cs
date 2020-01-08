using AspNetCoreIdentityCustomization.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreIdentityCustomization.Data
{
    interface IPosLogRepository
    {
        PostLog GetPostLog(int PostLogId);
        //PostLog AddPostLog(PostLog postLog);
        //IEnumerable<PostLog> GetListPostLog();
        //PostLog UpdatePostLog(PostLog postlog);
        //PostLog DeletePostLog(int PostLogId);

    }
}
