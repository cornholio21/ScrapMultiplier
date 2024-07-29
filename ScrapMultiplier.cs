// MIT License
// 
// Copyright (c) 2024 Cornholio21
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.


using Oxide.Core;
using Oxide.Core.Plugins;

namespace Oxide.Plugins
{
    [Info("Scrap Multiplier", "Cornholio21", "1.0.3")]
    [Description("Multiplies the amount of scrap found in crates.")]
    public class ScrapMultiplier : RustPlugin
    {
        private const int ScrapItemId = -932201673; // The item ID for scrap in Rust

        private float scrapMultiplier;

        // Load default configuration
        protected override void LoadDefaultConfig()
        {
            PrintWarning("Creating a new configuration file.");
            Config["ScrapMultiplier"] = 1.0f;
            SaveConfig();
        }

        // Initialize plugin configuration
        private void Init()
        {
            LoadConfigValues();
        }

        // Load configuration values
        private void LoadConfigValues()
        {
            // Try to get the ScrapMultiplier value from the configuration
            object configValue = Config["ScrapMultiplier"];
            if (configValue == null || !float.TryParse(configValue.ToString(), out scrapMultiplier))
            {
                // Set default value if parsing fails or value is not present
                scrapMultiplier = 1.0f;
                PrintWarning("Invalid or missing configuration value for ScrapMultiplier. Using default value 1.0.");
            }
        }

        // This hook is called when a crate's loot is generated
        private void OnLootSpawn(LootContainer container)
        {
            // Use NextFrame to manipulate loot after it has been populated
            NextFrame(() =>
            {
                // Iterate through all items in the loot container
                foreach (Item item in container.inventory.itemList)
                {
                    // Check if the item is scrap
                    if (item.info.itemid == ScrapItemId)
                    {
                        // Multiply the amount of scrap
                        item.amount = (int)(item.amount * scrapMultiplier);
                    }
                }
            });
        }
    }
}
