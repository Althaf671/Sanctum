import { GlobalActionGroup } from "@/features/dashboard/components/inputGroup";


export function AcademicMateriPage() {
    return (
        <div className="academic-materi-container flex flex-col gap-[1rem]">
        
            {/* Header */}
            <header className="flex w-auto h-[75px] border-1 border-black items-center justify-between">
                <span>Materi Manager</span>
                <GlobalActionGroup />
            </header>

        </div>
    );
}