import { Telemetry, TelemetryPost } from "./telemetry-interfaces";

export interface Machine {
  id: string;
  name: string;
  lastTelemetry: Telemetry;
}

export interface MachinePost {
  name: string;
  telemetry: TelemetryPost;
}