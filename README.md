# Description
Scrap Multiplier is a plugin for Rust that increases the amount of scrap found in crates. This plugin allows server administrators to configure a multiplier that scales the amount of scrap dropped from crates, without touching the loot tables. By default, the plugin is set to a multiplier of 1.0, meaning no change to the amount of scrap. Adjusting the multiplier in the configuration file will scale the amount of scrap accordingly.

# Installation
1. **Download the Plugin:** Save the provided plugin code into a file named ScrapMultiplier.cs.

2. **Upload the Plugin:** Upload ScrapMultiplier.cs to the oxide/plugins directory on your Rust server.

3. **Reload Oxide:** After uploading the plugin, you need to reload Oxide or restart your server. To manually reload the plugin, use the following command in your server console: oxide.reload ScrapMultiplier

# Usage

**Configuration**

1. **Generate Configuration File:** The plugin will automatically create a configuration file named ScrapMultiplier.json in the oxide/config directory the first time it is loaded.

2. **Edit the Configuration File:** Open oxide/config/ScrapMultiplier.json to modify the ScrapMultiplier value. Here’s an example configuration file: 
{
  "Scrap Multiplier": 2.0
}
    *  ScrapMultiplier: This value determines how much the amount of scrap will be multiplied. For example, a value of 2.0 will increase the scrap amount found in crates by 2.0 times.


3. **Reload the Plugin:** After editing the configuration file, reload the plugin to apply the changes: oxide.reload ScrapMultiplier

# License
This project is licensed under the MIT License. See the LICENSE file for more details.

# Contact
For any issues or contributions, please create an issue or pull request on the GitHub repository.