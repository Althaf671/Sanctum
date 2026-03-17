namespace src.Modules.Tools.ToolsApplication.Common.Model;

public record ImageMasterMetadataDetail(
    ImageExifMetadataDetail Exif
    // ImageIptcProfileMetadataDetail Iptc,
    // ImageXmpProfileMetadataDetail Xmp
);

public record ImageExifMetadataDetail(
    ExifCameraInfo ExifCameraInfo,
    ExifImageInfo ExifImageInfo,
    ExifCaptureInfo ExifCaptureInfo,
    ExifLocationInfo ExifLocationInfo,
    ExifPrivacyInfo ExifPrivacyInfo
);

public record ExifCameraInfo(
    string? Make,
    string? Model,
    string? Software,
    string? LenseMake,
    string? LenseModel,
    string? SerialNumber
);

public record ExifImageInfo(
    int? Width,
    int? Height,
    int? BitsPerSample,
    string? ColorSpace,
    string? Orientation,
    string? Compression,
    double? XResolution,
    double? YResolution
);

public record ExifCaptureInfo(
    string? DateTimeOriginal,
    string? DateTimeDigitized,
    double? ExposureTime,
    double? FNumber,
    double? FocalLength,
    string? Flash,
    string? SceneCaptureType
);

public record ExifLocationInfo(
    double? Latitude,
    double? Longitude,
    double? Altitude,
    string? LatitudeRef,
    string LongitudeRef,
    double? Speed,
    string? SpeedRef,
    double? ImageDirection,
    string? ImageDirectionRef,
    string? DateStamp,
    string TimeStamp
);

public record ExifPrivacyInfo(
    bool HasGps,
    bool HasDeviceSerial,
    bool HasCameraInfo,
    bool HasSoftwareInfo
);



public record ImageIptcProfileMetadataDetail();

public record ImageXmpProfileMetadataDetail();

