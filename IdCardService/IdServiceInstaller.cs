using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace IdCardService {
    [RunInstaller(true)]
    public partial class IdServiceInstaller : System.Configuration.Install.Installer {
        public IdServiceInstaller() {
            InitializeComponent();
        }
    }
}
