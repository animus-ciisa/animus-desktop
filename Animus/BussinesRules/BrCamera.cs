using Animus.Common;
using Animus.DataAccess;
using Animus.RestServices;
using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    class BrCamera
    {
        DaCamera daCamera;
        RsCamera rsCamera;
        DsDevice[] systemCamereas;

        public BrCamera()
        {
            this.daCamera = new DaCamera();
            this.rsCamera = new RsCamera();
            this.systemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
        }

        public Boolean UpdateCameras()
        {
            Boolean internetStatus = true;
            return this.rsCamera.Update(this.daCamera.All(), out internetStatus);
        }

        public void Save(CoCamera camera)
        {
            this.daCamera.Save(camera);
            this.UpdateCameras();
        }

        public List<CoCamera> GetSystemCameras()
        {
            List<CoCamera> cameras = this.daCamera.All();
            if (this.systemCamereas.Length > cameras.Count)
            {
                for (int i = 0; i < this.systemCamereas.Length; i++)
                {
                    Boolean isCreated = false;
                    for (int j = 0; j < cameras.Count; j++)
                    {
                        if(this.systemCamereas[i].Name.ToUpper() == cameras[j].name)
                        {
                            isCreated = true;
                            break;
                        }
                    }
                    if (!isCreated)
                    {
                        CoCamera camera = new CoCamera
                        {
                            name = this.systemCamereas[i].Name.ToUpper(),
                            status = true,
                            associate = false
                        };
                        this.daCamera.Save(camera);
                        cameras.Add(camera);
                    }
                }
            }else if (cameras.Count > this.systemCamereas.Length)
            {
                for (int i = 0; i < cameras.Count; i++)
                {
                    Boolean isOff = true;
                    for (int j = 0; j < this.systemCamereas.Length; j++)
                    {
                        if (this.systemCamereas[j].Name.ToUpper() == cameras[i].name)
                        {
                            isOff = false;
                            break;
                        }
                    }
                    if (isOff)
                    {
                        cameras[i].status = false;
                        this.daCamera.Save(cameras[i]);
                    }
                }
            }
            return cameras;
        }
    }
}
