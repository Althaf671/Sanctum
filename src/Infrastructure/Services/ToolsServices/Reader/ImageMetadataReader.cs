using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Infrastructure.Services.ToolsServices.Reader;
public class ImageMetadataReader : IImageMetadataReader
{
    public async Task<Result<ImageMasterMetadataDetail>> ReadImageMetadata(
        Memory<byte> file, 
        CancellationToken cancellationToken)
    {
        using var inputStream = new MemoryStream(file.ToArray());

        using var imageInstance = await Image.LoadAsync(inputStream, cancellationToken);

        var exifMetadata = ExifMetadataProfile(imageInstance);

        var masterMetadata = new ImageMasterMetadataDetail(exifMetadata);

        return Result<ImageMasterMetadataDetail>.Success(masterMetadata);
    }

    private static ImageExifMetadataDetail ExifMetadataProfile(Image imageInstance)
    {
        var exif = imageInstance.Metadata.ExifProfile;

        // Camera Info
        IExifValue<string>? model = null;
        IExifValue<string>? make = null;
        IExifValue<string>? software = null;
        IExifValue<string>? lensMake = null;
        IExifValue<string>? lensModel = null;
        IExifValue<string>? serialNum = null;

        if (exif != null)
        {
            exif?.TryGetValue(ExifTag.Model, out model);
            exif?.TryGetValue(ExifTag.Make, out make);
            exif?.TryGetValue(ExifTag.Software, out software);   
            exif?.TryGetValue(ExifTag.LensMake, out lensMake);
            exif?.TryGetValue(ExifTag.LensModel, out lensModel);       
            exif?.TryGetValue(ExifTag.SerialNumber, out serialNum); 
        }

        var cameraInfo = new ExifCameraInfo(
            Model: model?.Value,
            Make: make?.Value,
            Software: software?.Value,
            LenseMake: lensMake?.Value,
            LenseModel: lensModel?.Value,
            SerialNumber: serialNum?.Value  
        );

        // Image Info
        IExifValue<ushort[]>? bitsPerSample = null;
        IExifValue<ushort>? colorSpace = null;
        IExifValue<ushort>? orientation = null;
        IExifValue<ushort>? compression = null;
        IExifValue<Rational>? xResolution = null;
        IExifValue<Rational>? yResolution = null;

        if (exif != null)
        {
            exif.TryGetValue(ExifTag.BitsPerSample, out bitsPerSample);
            exif.TryGetValue(ExifTag.ColorSpace, out colorSpace);
            exif.TryGetValue(ExifTag.Orientation, out orientation);
            exif.TryGetValue(ExifTag.Compression, out compression);
            exif.TryGetValue(ExifTag.XResolution, out xResolution);
            exif.TryGetValue(ExifTag.YResolution, out yResolution);
        }

        var imageInfo = new ExifImageInfo(
            Width: imageInstance.Width,
            Height: imageInstance.Height,
            BitsPerSample: bitsPerSample?.Value?[0],
            ColorSpace:    colorSpace?.Value.ToString(),
            Orientation:   orientation?.Value.ToString(),
            Compression:   compression?.Value.ToString(),
            XResolution:   xResolution?.Value.ToDouble(),
            YResolution:   yResolution?.Value.ToDouble()
        );

        // capture info
        IExifValue<Rational>? exposureTime = null;
        IExifValue<Rational>? fNumber = null;
        IExifValue<Rational>? focalLength = null;
        IExifValue<ushort>?   flash = null;
        IExifValue<ushort>?   sceneCaptureType = null;
        IExifValue<string>?   dateTimeOriginal = null;
        IExifValue<string>?   dateTimeDigitized = null;

        if (exif != null)
        {
            exif.TryGetValue(ExifTag.ExposureTime, out exposureTime);
            exif.TryGetValue(ExifTag.FNumber, out fNumber);
            exif.TryGetValue(ExifTag.FocalLength, out focalLength);
            exif.TryGetValue(ExifTag.Flash, out flash);
            exif.TryGetValue(ExifTag.SceneCaptureType, out sceneCaptureType);
            exif.TryGetValue(ExifTag.DateTimeOriginal, out dateTimeOriginal);
            exif.TryGetValue(ExifTag.DateTimeDigitized, out dateTimeDigitized);
        }

        var captureInfo = new ExifCaptureInfo(
            DateTimeOriginal:  dateTimeOriginal?.Value,
            DateTimeDigitized: dateTimeDigitized?.Value,
            ExposureTime:      exposureTime?.Value.ToDouble(),
            FNumber:           fNumber?.Value.ToDouble(),
            FocalLength:       focalLength?.Value.ToDouble(),
            Flash:             flash?.Value.ToString(),
            SceneCaptureType:  sceneCaptureType?.Value.ToString()
        );

        // Location info
        IExifValue<Rational[]>? latitude = null;
        IExifValue<Rational[]>? longitude = null;
        IExifValue<Rational>?   altitude = null;
        IExifValue<string>?     latitudeRef = null;
        IExifValue<string>?     longitudeRef = null;
        IExifValue<Rational>?   speed = null;
        IExifValue<string>?     speedRef = null;
        IExifValue<Rational>?   imgDirection = null;
        IExifValue<string>?     imgDirectionRef = null;
        IExifValue<string>?     dateStamp = null;
        IExifValue<Rational[]>? timeStamp = null;

        if (exif != null)
        {
            exif.TryGetValue(ExifTag.GPSLatitude, out latitude);
            exif.TryGetValue(ExifTag.GPSLongitude, out longitude);
            exif.TryGetValue(ExifTag.GPSAltitude, out altitude);
            exif.TryGetValue(ExifTag.GPSLatitudeRef, out latitudeRef);
            exif.TryGetValue(ExifTag.GPSLongitudeRef, out longitudeRef);
            exif.TryGetValue(ExifTag.GPSSpeed, out speed);
            exif.TryGetValue(ExifTag.GPSSpeedRef, out speedRef);
            exif.TryGetValue(ExifTag.GPSImgDirection, out imgDirection);
            exif.TryGetValue(ExifTag.GPSImgDirectionRef, out imgDirectionRef);
            exif.TryGetValue(ExifTag.GPSDateStamp, out dateStamp);
            exif.TryGetValue(ExifTag.GPSTimestamp, out timeStamp);
        }

        var locationInfo = new ExifLocationInfo(
            Latitude:        latitude?.Value?[0].ToDouble(),
            Longitude:       longitude?.Value?[0].ToDouble(),
            Altitude:        altitude?.Value.ToDouble(),
            LatitudeRef:     latitudeRef?.Value,
            LongitudeRef:    longitudeRef?.Value!,
            Speed:           speed?.Value.ToDouble(),
            SpeedRef:        speedRef?.Value,
            ImageDirection:    imgDirection?.Value.ToDouble(),
            ImageDirectionRef: imgDirectionRef?.Value,
            DateStamp:       dateStamp?.Value,
            TimeStamp:       timeStamp?.Value?[0].ToDouble().ToString()!
        );

        // Privacy info
        var privacyInfo = new ExifPrivacyInfo(
            HasGps: latitude?.Value != null || longitude?.Value != null,
            HasCameraInfo: make?.Value != null || model?.Value != null,
            HasDeviceSerial: serialNum?.Value != null,
            HasSoftwareInfo: software?.Value != null
        );

        return new ImageExifMetadataDetail(
            cameraInfo,
            imageInfo,
            captureInfo,
            locationInfo,
            privacyInfo
        );
    }

}