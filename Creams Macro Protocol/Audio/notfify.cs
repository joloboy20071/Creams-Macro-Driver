using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Creams_Macro_Protocol.audio;
/*
namespace Creams_Macro_Protocol;

public partial class audio
{
    public class SessionCreatedEventArgs : EventArgs
    {
        
        public IAudioSessionControl2 NewSession { get; private set; }

        
        public SessionCreatedEventArgs(IAudioSessionControl2 newSession)
        {
            if (newSession == null)
                throw new ArgumentNullException("newSession");
            NewSession = newSession;
        }
    }

    [ComImport]
    [Guid("641DD20B-4D41-49CC-ABA3-174B9477BB08")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

    public interface IAudioSessionNotification
    {
        /// <summary>
        /// Notifies the registered processes that the audio session has been created.
        /// </summary>
        /// <param name="newSession">Pointer to the <see cref="AudioSessionControl"/> object of the audio session that was created.</param>
        /// <returns>HRESULT</returns>
        [PreserveSig]
        int OnSessionCreated([In] IntPtr newSession); //newSession is a pointer to an IAudioSessionControl interface
    }
}


[Guid("641DD20B-4D41-49CC-ABA3-174B9477BB08")]
    public sealed class AudioSessionNotification : IAudioSessionNotification
    {


    public event EventHandler<SessionCreatedEventArgs> SessionCreated;



    int IAudioSessionNotification.OnSessionCreated([In] IntPtr newSession)
        {
            if (SessionCreated != null)
            {
                var sessionControl = 
     
                ((IUnknown)sessionControl).AddRef();
                SessionCreated(this, new SessionCreatedEventArgs(sessionControl));
            }
            return (int)HResult.S_OK;
        }
    }






    internal class notfify
    {











    }
}*/