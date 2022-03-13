using System;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

namespace Xternity.Extension
{
    public class UnityWebRequestAwaiter : INotifyCompletion
    {
        public bool IsCompleted => _asyncOp.isDone;

        private UnityWebRequestAsyncOperation _asyncOp;
        private Action _continuation;
        
        public UnityWebRequestAwaiter(UnityWebRequestAsyncOperation asyncOp)
        {
            _asyncOp = asyncOp;
            asyncOp.completed += OnRequestCompleted;
        }

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
        }
        
        public void GetResult()
        {
        }
        
        private void OnRequestCompleted(UnityEngine.AsyncOperation obj)
        {
            _continuation?.Invoke();
        }
    }
    public static class ExtensionMethods
    {
        public static UnityWebRequestAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
        {
            return new UnityWebRequestAwaiter(asyncOp);
        }
    }
}