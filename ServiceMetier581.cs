using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Life;
using Life.DB;
using Life.Network;
using Mirror;
using ModKit.Helper;
using ModKit.Interfaces;

namespace ServiceMetier581
{
    public class ServiceMetier581 : ModKit.ModKit
    {
        private readonly MyEvents _events;

        public ServiceMetier581(IGameAPI api) : base(api)
        {
            PluginInformations = new PluginInformations(AssemblyHelper.GetName(), "1.0", "Shape581");
            _events = new MyEvents(api);
        }

        public override void OnPluginInit()
        {
            base.OnPluginInit();
            _events.Init(Nova.server);
            ModKit.Internal.Logger.LogSuccess($"{PluginInformations.SourceName} v{PluginInformations.Version}", "initialisé");
        }

        public class MyEvents : ModKit.Helper.Events
        {
            public MyEvents(IGameAPI api) : base(api)
            {
            }

            public override void OnPlayerSpawnCharacter(Player player)
            {
                base.OnPlayerSpawnCharacter(player);

                int bizId = player.biz.Id;
                if (bizId > 0)
                {
                    player.serviceMetier = true;
                    player.Notify("INFORMATION", "Votre service métier a bien été activé automatiquemnt.", NotificationManager.Type.Info);
                }
            }
        }
    }
}
