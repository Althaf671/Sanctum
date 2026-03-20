import { GlobalActionGroup } from "@/features/dashboard/components/inputGroup";
import { Separator } from "@workspace/ui/components/separator";

export function AcademicHomePage() {
    return (
        <div className="academic-home-container">
            
            {/* Header */}
            <header className="flex w-auto min-h-[75px] items-center justify-between">
                <div className="flex flex-col">
                    <span className="text-[1.75rem]">Academia</span>
                    <span className="text-[0.75rem] opacity-[60%] tracking-[0.15px]">Organize your courses, tasks & study materials from one space.</span>
                </div>
                <GlobalActionGroup />
            </header>
            <Separator className="-mt-[1px]" />

            
        </div>
    );
}