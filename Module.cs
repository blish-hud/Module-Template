using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Blish_HUD;
using Blish_HUD.Modules;
using Blish_HUD.Modules.Managers;
using Blish_HUD.Settings;
using Microsoft.Xna.Framework;

namespace $username$.$safeprojectname$ {

    [Export(typeof(Blish_HUD.Modules.Module))]
    public class Module : Blish_HUD.Modules.Module {

        private static readonly Logger Logger = Logger.GetLogger(typeof(Module));

        internal static Module ModuleInstance;

        #region Service Managers
        internal SettingsManager    SettingsManager    => this.ModuleParameters.SettingsManager;
        internal ContentsManager    ContentsManager    => this.ModuleParameters.ContentsManager;
        internal DirectoriesManager DirectoriesManager => this.ModuleParameters.DirectoriesManager;
        internal Gw2ApiManager      Gw2ApiManager      => this.ModuleParameters.Gw2ApiManager;
        #endregion

        [ImportingConstructor]
        public Module([Import("ModuleParameters")] ModuleParameters moduleParameters) : base(moduleParameters) { ModuleInstance = this; }

        protected override void DefineSettings(SettingCollection settings) {
            
        }

        protected override void Initialize() {
            
        }

        protected override async Task LoadAsync() {
            
        }

        protected override void OnModuleLoaded(EventArgs e) {
            
            // Base handler must be called
            base.OnModuleLoaded(e);
        }

        protected override void Update(GameTime gameTime) {
            
        }

        /// <inheritdoc />
        protected override void Unload() {
            // Unload

            // All static members must be manually unset
            ModuleInstance = null;
        }

    }

}
