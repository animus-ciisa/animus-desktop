using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace Animus.BussinesRules
{
    class BrBatch
    {
        private BrSesion brSession;
        private BrCamera brCamera;

        public BrBatch()
        {
            this.brSession = new BrSesion();
            this.brCamera = new BrCamera();
        }

        public void StartProcess()
        {
            var renewTokenTimer = new Timer((e) =>
            {
                Console.WriteLine("Se actualizara token");
                RenewTokenProcess();
            }, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(20));

            var updateCameraTimer = new Timer((e) =>
            {
                Console.WriteLine("Se actualizara camaras");
                UpdateCameraProcess();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

        }

        private void RenewTokenProcess()
        {
            Boolean internetStatus;
            this.brSession.UpdateToken(out internetStatus);
        }

        private Boolean UpdateCameraProcess()
        {
            Boolean internetStatus;
            return this.brCamera.UpdateCameras();
        }

    }
}
