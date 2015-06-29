
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epicor.ServiceModel;
using Ice.Lib.Framework;
using Ice.Lib.App;
using Ice.UI.Shared;
using Ice.Contracts;
using Ice.Lib.Broadcast;
using Ice.CustomUI.PRList;

namespace Ice.Lib.App
{
    public class Launch : EpiBaseLaunch
    {
        protected override void InitializeLaunch()
        {
            base.UITrans = new Ice.CustomUI.PRList.Transaction(this);
            base.UIForm = new PRList(base.UITrans);
        }
    }
}
