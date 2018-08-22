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

* Save feature saves only one image while ICNS may contain a few different images.

## Usage

To use the codec you should add `BrokenEvent.Icns` to the project (in binary dll form or as sources).

### JP2000 Codec

There are still no lightweight managed *JP2000* codec. [CSJ2K](https://github.com/cureos/csj2k) is unable to open 256x256 and 512x512 images in example ICNSes
and falls with different errors. The temporary solution is use giant like *FreeImage* (which is native requires to lock app architecture to x86 (or x64)).
I say giant because I have to use 5.5MB native lib just for single codec.

If you have different usable codec for JP2000, you should disable `_FREEIMAGE` preprocessor symbol and set your own
callback method to `BrokenEvent.LibIcns.IcnsDecoder.LoadJ2kImage`.

### Loading

To load .ICNS image you should call:

```CSharp
    IcnsImageParser.GetImages(filename)
```
or
```CSharp
    IcnsImageParser.GetImages(stream)
```

The result is `List` of `IcnsImage`. It is simple container for the `System.Drawing.Bitmap` and the format of the image.

You can also use
```CSharp
    IcnsImageParser.GetImage(filename)
```
to return the largest loaded image from the file or stream.

### Saving

To save the .ICNS you should use
```CSharp
    IcnsImageParser.WriteImage(bitmap, filename)
```

or the `System.IO.Stream` overload.