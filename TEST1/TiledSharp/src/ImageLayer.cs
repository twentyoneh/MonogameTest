
using System;
using System.Xml.Linq;

namespace TiledSharp
{
    public class TmxImageLayer : ITmxLayer
    {
        public string Name {get; private set;}

        // TODO: Legacy (Tiled Java) attributes (x, y, width, height)
        public int? Width {get; private set;}
        public int? Height {get; private set;}

        public bool Visible {get; private set;}
        public double Opacity {get; private set;}
        public double OffsetX {get; private set;}
        public double OffsetY {get; private set;}

        public TmxImage Image {get; private set;}

        public PropertyDict Properties {get; private set;}

        double? ITmxLayer.OffsetX => OffsetX;
        double? ITmxLayer.OffsetY => OffsetY;

        public TmxImageLayer(XElement xImageLayer, string tmxDir = "")
        {
            Name = (string) xImageLayer.Attribute("name");

            Width = (int?) xImageLayer.Attribute("width");
            Height = (int?) xImageLayer.Attribute("height");
            Visible = (bool?) xImageLayer.Attribute("visible") ?? true;
            Opacity = (double?) xImageLayer.Attribute("opacity") ?? 1.0;
            OffsetX = (double?) xImageLayer.Attribute("offsetx") ?? 0.0;
            OffsetY = (double?) xImageLayer.Attribute("offsety") ?? 0.0;

            Image = new TmxImage(xImageLayer.Element("image"), tmxDir);

            Properties = new PropertyDict(xImageLayer.Element("properties"));
        }
    }
}
