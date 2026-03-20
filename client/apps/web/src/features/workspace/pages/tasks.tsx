import { GlobalActionGroup } from "@/features/dashboard/components/inputGroup";
import { Separator } from "@workspace/ui/components/separator";

export function TasksPage() {
    return (
        <div className="tasks-container flex flex-col gap-[1.5rem]">
            
            {/* Header */}
            <header className="flex w-auto min-h-[75px] items-center justify-between">
                <div className="flex flex-col">
                    <span className="text-[1.75rem]">Tasks</span>
                    <span className="text-[0.75rem] opacity-[60%] tracking-[0.15px]">Convert, manage, and manipulate your document or image</span>
                </div>
                <GlobalActionGroup />
            </header>
            <Separator className="-mt-[25px]" />
        </div>
    );
}