using System;
using System.Collections.Generic;
using System.Text;

namespace AppMallas.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
