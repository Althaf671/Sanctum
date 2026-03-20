import { MainLayout } from "@/components/main-layout";
import { AcademicHomePage } from "@/features/academic/pages/home";
import { AcademicMataKuliahPage } from "@/features/academic/pages/matakuliah";
import { AcademicMateriPage } from "@/features/academic/pages/materi";
import { AcademicPertemuanPage } from "@/features/academic/pages/pertemuan";
import { AcademicTugasPage } from "@/features/academic/pages/tugas";
import { DashboardOverviewPage } from "@/features/dashboard/pages/overview";
import { WorkshopHomePage } from "@/features/tools/pages/workshop";
import { CalendarPage } from "@/features/workspace/pages/calendar";
import { DocsPage } from "@/features/workspace/pages/docs";
import { DrivePage } from "@/features/workspace/pages/drive";
import { FormsPage } from "@/features/workspace/pages/forms";
import { SheetsPage } from "@/features/workspace/pages/sheets";
import { TasksPage } from "@/features/workspace/pages/tasks";
import { createBrowserRouter } from "react-router-dom";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <MainLayout />,
        children: [
            { path: 'dashboard/home', element: <DashboardOverviewPage />},
            { path: 'academic/home', element: <AcademicHomePage />},
            { path: 'academic/matakuliah', element: <AcademicMataKuliahPage />},
            { path: 'academic/materi', element: <AcademicMateriPage />},
            { path: 'academic/pertemuan', element: <AcademicPertemuanPage />},
            { path: 'academic/tugas', element: <AcademicTugasPage />},
            { path: 'workshop/home', element: <WorkshopHomePage /> },
            { path: 'workspace/forms', element: <FormsPage /> },
            { path: 'workspace/tasks', element: <TasksPage /> },
            { path: 'workspace/calendar', element: <CalendarPage /> },
            { path: 'workspace/docs', element: <DocsPage /> },
            { path: 'workspace/sheets', element: <SheetsPage /> },
            { path: 'workspace/drive', element: <DrivePage /> },
        ]
    }
]);


