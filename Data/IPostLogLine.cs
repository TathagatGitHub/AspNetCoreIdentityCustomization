using AspNetCoreIdentityCustomization.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AspNetCoreIdentityCustomization.Data
{
    interface IPostLogLine
    {
        //IPostLogLine GetPostLogLine(int PostLogId);
        //IEnumerable<IPostLogLine> GetPostLogLineList();
        public void InsertBulkPostLogLineAsync(IEnumerable<PostLogLine> postLogLines);
        
    }
}
