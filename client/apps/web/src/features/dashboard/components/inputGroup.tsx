import { InputGroup, InputGroupAddon, InputGroupInput } from "@workspace/ui/components/input-group";
import { Notification, SearchCheck } from "@hugeicons/core-free-icons";
import { HugeiconsIcon } from "@hugeicons/react";
import { Button } from "@workspace/ui/components/button";
import { Avatar, AvatarFallback, AvatarImage } from "@workspace/ui/components/avatar";

export function GlobalActionGroup() {
    return (
        <div className="global-action-group flex gap-[0.5rem]">
            <InputGroup className="max-w-xs">
                <InputGroupInput placeholder="Search by keywords" />
                    <InputGroupAddon>
                        <HugeiconsIcon 
                            style={{ width: "18px", height: "18px" }} 
                            icon={SearchCheck} 
                            strokeWidth={1.5} 
                        />
                    </InputGroupAddon>
                <InputGroupAddon align="inline-end">12 results</InputGroupAddon>
            </InputGroup>
                <Button variant="outline" size="icon">
                    <HugeiconsIcon 
                        style={{ width: "18px", height: "18px" }} 
                        icon={Notification} 
                        strokeWidth={1.5} 
                    />
                </Button>
                <Button variant="outline" size="icon">
                    <Avatar>
                    <AvatarImage
                        src="https://github.com/evilrabbit.png"
                        alt="@evilrabbit"
                    />
                    <AvatarFallback>AM</AvatarFallback>
                    </Avatar>
                </Button>
        </div>
    );
}