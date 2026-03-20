import { GlobalActionGroup } from "@/features/dashboard/components/inputGroup";
import { 
    AiImageIcon, 
    FileRemoveIcon, 
    Files01Icon, 
    Office365Icon, 
    Pdf01Icon 
} from "@hugeicons/core-free-icons";
import { HugeiconsIcon } from "@hugeicons/react";
import { Button } from "@workspace/ui/components/button";
import { 
    Card, 
    CardContent, 
    CardFooter, 
    CardHeader, 
    CardTitle 
} from "@workspace/ui/components/card";
import { Link } from "react-router-dom";

interface IWorkshopItem {
    readonly name: string;
    readonly link: string;
    readonly icon: any;
    readonly desc: string;
    readonly actionName: string;
}

const workshopItem: IWorkshopItem[] = [
    { 
        name: "PDF to Office", 
        link: "/workshop/document-to-pdf", 
        icon: Office365Icon, 
        desc: "Convert PDF to DOCX, XLXS, CSV & PPTX via Google sheets and docs.",
        actionName: "Convert PDF"
    },
    { 
        name: "Image Converter", 
        link: "/", 
        icon: AiImageIcon, 
        desc: "Convert JPG, JPEG, PNG, and more image formats.",
        actionName: "Convert Image"
    },
    { 
        name: "Office to PDF", 
        link: "/", 
        icon: Pdf01Icon, 
        desc: "Convert DOCX, XLXS, PPTX, CSV, and more extension to PDF.",
        actionName: "Convert to PDF"
    },
    { 
        name: "Metadata Cleaner", 
        link: "/", 
        icon: FileRemoveIcon, 
        desc: "Strip hidden metadata, GPS & timestamps from PDF, image or docs.",
        actionName: "Clean File"
    },
    { 
        name: "PDF Manipulator", 
        link: "/", 
        icon: Files01Icon, 
        desc: "Merge, split, compress, rotate & watermark you PDF files in one place.",
        actionName: "Get Started"
    },
    { 
        name: "Image Compressor", 
        link: "/", 
        icon: Files01Icon, 
        desc: "Compress JPG, PNG, & JPEG without losing quality.",
        actionName: "Compress Now"
    },
] 

export function WorkshopHomePage() {
    return (
        <div className="workshop-home-page-container flex flex-col gap-[1.5rem]">
            
            {/* Header */}
            <header className="flex w-auto min-h-[75px] items-center justify-between border-b-[1px] border-[dark]">
                <div className="flex flex-col">
                    <span className="text-[1.75rem]">Workshop</span>
                    <span className="text-[0.75rem] opacity-[60%] tracking-[0.15px]">Convert, manage, and manipulate your document or image</span>
                </div>
                <GlobalActionGroup />
            </header>
            
            {/* workshop grid */}
            <div className="workshop-grid-container grid grid-cols-2 sm:grid-cols-3 md:grid-cols-3 lg:grid-cols-3 gap-[1.5rem]">
            {workshopItem.map((item) => (
                <Link to={item.link}>
                    <Card className="flex flex-row justify-between flex-1 min-h-[165px] px-2 py-3">
                        <div className="left-card w-[80%] flex flex-col justify-between">
                            <div className="upper-left-card flex flex-col">
                                <CardHeader>
                                <CardTitle className="text-[1rem]">{item.name}</CardTitle>
                                </CardHeader>
                                <CardContent className="mt-1 opacity-[60%]">
                                    <p className="text-[12px]">{item.desc}</p>
                                </CardContent>
                            </div>
                            <CardFooter>
                                <Button className="cursor-pointer">{item.actionName}</Button>
                            </CardFooter>
                        </div>
                        <div className="right-card flex flex-col items-center justify-center w-[25%]">
                            <HugeiconsIcon 
                                icon={item.icon} 
                                style={{ width: "60px", height: "60px", marginTop: "-10px", marginRight: "20px" }} 
                                strokeWidth={1.5}
                            />
                        </div>
                    </Card>
                </Link>
            ))}
            </div>
        </div>
    );
}