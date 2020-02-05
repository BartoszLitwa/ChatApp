using ChatApp.Core;
using System.Threading.Tasks;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// The interface for every single command needed to handle Friend Lists, Chat History etc.
    /// </summary>
    public interface ISQLCommandSender
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstUser"></param>
        /// <param name="secondUser"></param>
        /// <returns></returns>
        Task<int> CreateTabelAsync(string firstUser, string secondUser, SQLTableTypeEnum type);
    }
}
