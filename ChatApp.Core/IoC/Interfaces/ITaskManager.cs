using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    /// <summary>
    /// Handles anythingto do with Tasks
    /// </summary>
    public interface ITaskManager
    {
        #region VOID RunAndForget

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);


        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// Task(TResult) returned by function.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// Task(TResult) returned by function.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a Task(TResult)
        /// object that represents that work. A cancellation token allows the work to be
        /// cancelled.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task`1
        /// object that represents that work.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work. A cancellation token allows the work to be
        /// cancelled.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <remarks> 
        ///     The passed in Task be awaited as it is to be run and forgotten
        ///     Any erros thronw will get logged to the ILogger in the DI provider
        /// </remarks>
        /// <returns></returns>
        void RunAndForget(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        #endregion

        #region Task Run

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task Run(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// Task(TResult) returned by function.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// Task(TResult) returned by function.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a Task(TResult)
        /// object that represents that work. A cancellation token allows the work to be
        /// cancelled.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task`1
        /// object that represents that work.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work. A cancellation token allows the work to be
        /// cancelled.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        /// <returns></returns>
        Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0); 

        #endregion
    }
}
