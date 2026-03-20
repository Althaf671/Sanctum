import { Clock05Icon } from "@hugeicons/core-free-icons";
import { HugeiconsIcon } from "@hugeicons/react";
import { 
    Card, 
    CardContent, 
    CardHeader, 
    CardTitle 
} from "@workspace/ui/components/card";

export function ActivityLog() {
    return (
        <Card className="w-[27.5%]">
            <CardHeader className="flex">
                <HugeiconsIcon 
                    icon={Clock05Icon}
                    style={{ width: "22px", height: "22px", marginTop: "-2px" }} 
                    strokeWidth={1.5}
                />
                <CardTitle>Activity Log</CardTitle>
            </CardHeader>
            <CardContent>

            </CardContent>
        </Card>
    );
}