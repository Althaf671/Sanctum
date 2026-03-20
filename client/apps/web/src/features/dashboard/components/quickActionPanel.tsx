import { Compass } from "@hugeicons/core-free-icons";
import { HugeiconsIcon } from "@hugeicons/react";
import { Card, CardContent, CardHeader, CardTitle } from "@workspace/ui/components/card";


export function QuickActionPanel() {
    return (
        <Card className="w-[27.5%] h-[120px]">
            <CardHeader className="flex">
                <HugeiconsIcon 
                        icon={Compass}
                        style={{ width: "22px", height: "22px", marginTop: "-2px" }} 
                        strokeWidth={1.5}
                    />
                <CardTitle>Quick Actions</CardTitle>
            </CardHeader>
            <CardContent>

            </CardContent>
        </Card>
    );
}