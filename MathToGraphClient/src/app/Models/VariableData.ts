export class VariableData {
  constructor(varName: string, data = '') {
    this.variableName = varName;
    this.data = data;
  }
  variableName: string;
  data: string;
}
