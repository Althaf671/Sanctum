import { SidebarInset, SidebarProvider, SidebarTrigger } from "@workspace/ui/components/sidebar";
import { Outlet } from "react-router-dom";
import { AppSidebar } from "./sidebar";
import { TooltipProvider } from "@workspace/ui/components/tooltip";
import { BreadcrumbComponent } from "./breadcrumbs";
import { Clock } from "./clock";

export function MainLayout() {
    return (
        <SidebarProvider>
            <TooltipProvider>
                <div className="main-layout flex bg-sidebar w-[100%] justify-between h-screen">

                    {/* Sidebar */}
                    <AppSidebar />

                    {/* content */}
                    <SidebarInset>
                    <main className="content-container mt-2 pb-[4rem] px-[2.5rem] w-[100%] rounded-tl-lg">
                        <div className="toggle-and-breadcrumb h-[45px] mt-2 flex flex-row items-center">
                            <SidebarTrigger />
                            <BreadcrumbComponent />
                            <Clock />
                        </div>
                        <Outlet />
                    </main>
                    </SidebarInset>

                </div>
            </TooltipProvider>
        </SidebarProvider>
    );
}