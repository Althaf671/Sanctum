import { 
    BookAlertIcon, 
    TaskDone01Icon, 
    TaskRemove01Icon 
} from "@hugeicons/core-free-icons";
import type { IMetricCardItems } from "./component.types";

export const metricCard: IMetricCardItems[] = [
    { 
        title: "Total Materi", 
        curentValue:  0, 
        targetValue: 0,
        desc: "", 
        icon: TaskDone01Icon 
    },
    { 
        title: "Total Tugas", 
        curentValue: 0, 
        targetValue: 0,
        desc: "",
        icon: TaskRemove01Icon 
    },
    { 
        title: "Total Pertemuan", 
        curentValue: 0, 
        targetValue: 0,
        desc: "", 
        icon: BookAlertIcon 
    }
]