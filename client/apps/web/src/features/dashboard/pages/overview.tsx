import { GlobalActionGroup } from "../components/inputGroup";
import { ActivityLog } from "../components/activityLog";
import { TabsSummary } from "../components/tabs";
import { QuickActionPanel } from "../components/quickActionPanel";
import { MetricGroup } from "../components/metric-group/component";
import { Separator } from "@workspace/ui/components/separator";

export function DashboardOverviewPage() {
    return (
        <div className="dashboard-overview-container flex flex-col gap-[1.5rem]">

            {/* Header */}
            <header className="flex w-auto h-[75px] items-center justify-between">
                <div className="flex flex-col">
                    <span className="text-[1.75rem]">Hello, Althaf Mulya</span>
                    <span className="text-[12px] opacity-[60%] tracking-[0.15px]">Welcome to your KestSpace overview.</span>
                </div>
                <GlobalActionGroup />
            </header>
            <Separator className="-mt-[25px]" />
            
            {/* Overview Tabs and Activity log */}
            <div className="flex w-[100%] min-h-[350px] justify-between">
                <TabsSummary />
                <ActivityLog />
            </div>

            {/* Metric group and quick action panel */}
            <div className="flex w-[100%] min-h-[150px] justify-between">
                <MetricGroup />
                <QuickActionPanel />
            </div>

        </div>
    );
}