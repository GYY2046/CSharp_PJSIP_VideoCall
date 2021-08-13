using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pj_csharp
{

    enum pjmedia_vid_dev_hwnd_type
    {
        /**
         * Type none.
         */
        PJMEDIA_VID_DEV_HWND_TYPE_NONE,

        /**
         * Native window handle on Windows.
         */
        PJMEDIA_VID_DEV_HWND_TYPE_WINDOWS,

        /**
         * Native view on iOS.
         */
        PJMEDIA_VID_DEV_HWND_TYPE_IOS,

        /**
         * Native window handle on Android.
         */
        PJMEDIA_VID_DEV_HWND_TYPE_ANDROID

    } 
}
