# BrokenEvent.Icns
.ICNS is OS X icon format (used as replacement of the Windows .ICO). This is also a container of the images of different sizes and compression methods.

This repository contains the C# implementation of reader of the .ICNS file format.
Simple demo app and some test .ICNS files are included.

## The Source
Broken Event does not claim to be author of the original code.

The original is Java framework from here:

[http://code.google.com/p/appengine-awt/](http://code.google.com/p/appengine-awt/)

The Broken Event has translated into C# and refactored the code.

## Known Issues

* 256x256 and 512x512 32-bit images are not supported and will be skipped during loading. This will be fixed after adding proper J2k codec.
* Save feature saves only one image while ICNS may contain a few different images.

## Future plans
To fix issues described above.

## Usage

To use the codec you should add BrokenEvent.Icns to the project (in binary dll form or as sources).

### Loading

To load .ICNS image you should call:

    IcnsImageParser.GetImages(filename)

or

    IcnsImageParser.GetImages(stream)

The result is List of IcnsImage. It is simple container for the System.Drawing.Bitmap and the format of the image.
Beware that for unsupported images (see "Issues" section above) method will still return an IcnsImage item with Bitmap=null but with filled Type property.

You can also use

    IcnsImageParser.GetImage(filename)

to return the largest loaded image from the file or stream.

### Saving

To save the .ICNS you should use

    IcnsImageParser.WriteImage(bitmap, filename)

or its System.IO.Stream overload.