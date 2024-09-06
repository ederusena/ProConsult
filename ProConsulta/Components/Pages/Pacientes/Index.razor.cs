using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Patients;

namespace ProConsulta.Components.Pages.Pacientes;

public class IndexPage : ComponentBase
{
    [Inject] public IPatientRepository _patientRepository { get; set; } = null!;

    [Inject] public IDialogService Dialog { get; set; } = null!;

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    public List<Patient> Patients { get; set; } = new();

    public async Task DeletePatient(Patient patient)
    {
        try
        {
            var result = await Dialog.ShowMessageBox(
                "Atenção",
                $"Deseja apagar o paciente {patient.Name}?",
                "SIM",
                cancelText: "Cancel"
            );

            if (result is true)
            {
                await _patientRepository.DeleteByIdAsync(patient.Id);
                Snackbar.Add($"Patiente {patient.Name}, excluído com sucesso!", Severity.Success);
                await OnInitializedAsync();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    public void GoToUpdate(int id)
    {
        NavigationManager.NavigateTo($"/pacientes/update/{id}");
    }

    protected override async Task OnInitializedAsync()
    {
        Patients = await _patientRepository.GetAllAsync();
    }
}