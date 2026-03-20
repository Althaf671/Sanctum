import { GlobalActionGroup } from "@/features/dashboard/components/inputGroup";

export function AcademicTugasPage() {
    return (
        <div className="academic-tugas-container flex flex-col gap-[1rem]">
        
            {/* Header */}
            <header className="flex w-auto h-[75px] border-1 border-black items-center justify-between">
                <span>Hello, Althaf Mulya</span>
                <GlobalActionGroup />
            </header>
            
        </div>
    );
}