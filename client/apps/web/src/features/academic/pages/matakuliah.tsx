import { GlobalActionGroup } from "@/features/dashboard/components/inputGroup";

export function AcademicMataKuliahPage() {
    return (
        <div className="academic-matakuliah-container flex flex-col gap-[1rem]">
        
            {/* Header */}
            <header className="flex w-auto h-[75px] items-center justify-between">
                <span>Mata Kuliah Manager</span>
                <GlobalActionGroup />
            </header>

        </div>
    );
}