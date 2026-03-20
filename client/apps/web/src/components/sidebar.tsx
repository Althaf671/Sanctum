import { HugeiconsIcon } from "@hugeicons/react";
import { 
    Calendar01Icon,
    CanvasIcon, 
    DashboardSpeed02Icon, 
    GoogleDocIcon, 
    GoogleDriveIcon, 
    GoogleSheetIcon, 
    LicenseIcon, 
    Mortarboard02Icon, 
    Note03Icon, 
    Settings02Icon, 
    ToolsIcon 
} from "@hugeicons/core-free-icons";
import { 
    Sidebar, 
    SidebarContent, 
    SidebarFooter, 
    SidebarGroup, 
    SidebarGroupLabel, 
    SidebarHeader, 
    SidebarMenu, 
    SidebarMenuButton,
    SidebarMenuItem
} from "@workspace/ui/components/sidebar";
import { Link, useLocation } from "react-router-dom";

interface ISidebarItems {
    name: string;
    icon: any;
    link: string;
}

const appSidebarItems: ISidebarItems[] = [
    { name: 'Dashboard', link: '/dashboard/home', icon: DashboardSpeed02Icon },
    { name: 'Academia', link: '/academic/home', icon: Mortarboard02Icon },
    { name: 'Workshop', link: '/workshop/home', icon: ToolsIcon }
]

const workspaceSidebarItems: ISidebarItems[] = [
    { name: 'Tasks', link: '/workspace/tasks', icon: Note03Icon },
    { name: 'Calendar', link: '/workspace/calendar', icon: Calendar01Icon },
    { name: 'Docs', link: '/workspace/docs', icon: GoogleDocIcon },
    { name: 'Sheets', link: '/workspace/sheets', icon: GoogleSheetIcon },
    { name: 'Forms', link: '/workspace/forms', icon: LicenseIcon },
    { name: 'Drive', link: '/workspace/drive', icon: GoogleDriveIcon },
]

export function AppSidebar() {
    const location = useLocation();

    return (
        <Sidebar 
            collapsible="icon" 
            className="flex flex-col items-center w-[220px] h-[100vh]"
        >

            {/* Logo and Toggle */}
            {/* <SidebarHeader className="flex flex-row flex-nowrap">
                <SidebarMenuItem className="flex">
                    <span className="brand-name">
                        <h1 className="text-xl">KestSpace</h1>
                        <p className="text-[12px]">Kestrel Integrated Workspace</p>
                    </span>
                    <span className="brand-logo ">
                        Logo
                    </span>
                </SidebarMenuItem>
            </SidebarHeader> */}

            {/* Navigation items */}
            <SidebarContent className="flex flex-col gap-[1.15rem] mt-[20px] gap-[2.5rem]">
                <SidebarGroup className="flex flex-col gap-[0.75rem] ">
                    <SidebarGroupLabel className="-mb-2">Application</SidebarGroupLabel>
                    {appSidebarItems.map((item) => (
                        <SidebarMenuButton asChild isActive={location.pathname == item.link} tooltip={item.name}>
                            <Link to={item.link} className="flex items-center gap-3">
                                <HugeiconsIcon 
                                    style={{ width: "20px", height: "20px", marginTop: "-1px", marginLeft: "-2px" }} 
                                    icon={item.icon} 
                                    strokeWidth={1.5} 
                                />
                                <span className="text-[0.75rem] tracking-[0.15px]">{item.name}</span>
                            </Link>
                        </SidebarMenuButton>
                    ))}
                </SidebarGroup>

                <SidebarGroup className="flex flex-col gap-[0.75rem] ">
                    <SidebarGroupLabel className="-mb-2">Workspace</SidebarGroupLabel>
                    {workspaceSidebarItems.map((item) => (
                        <SidebarMenuButton asChild isActive={location.pathname == item.link} tooltip={item.name}>
                            <Link to={item.link} className="flex items-center gap-3">
                                <HugeiconsIcon 
                                    style={{ width: "20px", height: "20px", marginTop: "-1px", marginLeft: "-2px" }} 
                                    icon={item.icon} 
                                    strokeWidth={1.5} 
                                />
                                <span className="text-[0.75rem] tracking-[0.15px]">{item.name}</span>
                            </Link>
                        </SidebarMenuButton>
                    ))}
                </SidebarGroup>
            </SidebarContent>

            {/* Sidebar footer */}
            <SidebarFooter>
                <SidebarMenu>
                <SidebarMenuItem>
                    <SidebarMenuButton tooltip="Settings">
                        <Link to="/setting" className="flex items-center gap-3">
                            <HugeiconsIcon 
                                style={{ width: "20px", height: "20px", marginTop: "-1px", marginLeft: "-2px" }} 
                                icon={Settings02Icon} 
                                strokeWidth={1.5} 
                            />
                            <span className="text-[0.75rem] tracking-[0.15px]">Settings</span>
                        </Link>
                    </SidebarMenuButton>
                </SidebarMenuItem>
                </SidebarMenu>
            </SidebarFooter>

        </Sidebar>
    );
}