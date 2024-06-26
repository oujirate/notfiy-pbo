﻿using System;
using Npgsql;
using notfiy.Entities;
using notfiy.Core;

namespace notfiy.Models
{
    internal class NoteModel : Model
    {
        public List<Notes> GetAllNote()
        {
            List<Notes> ListNotes = new List<Notes>();

            NpgsqlCommand npgsqlCommand = new NpgsqlCommand("SELECT * FROM notes", Connection);
            NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
            //ListNotes.Clear();
            while (reader.Read())
            {
                Notes notes = new Notes
                {
                    IdNote = (int)reader["id_note"],
                    Note = (string)reader["note"],
                    ImageFileName = (string)reader["image_filename"],
                    NoteTimeCreated = (string)reader["note_time_created"],
                    IdUsers = (int)reader["id_users"],
                    IdLabels = (int)reader["id_label"],
                    IdPinnedItems = (int)reader["id_pinned_item"],
                    IdNoteStatus = (int)reader["id_note_status"]
                };
                ListNotes.Add(notes);
            }
            return ListNotes;
        }

        public bool CreateNote(Notes note)
        {
            try
            {
                Connection.Open();
                string insert = @"INSERT INTO notes (id_note, note, image_filename, note_time_created, id_users, id_label, id_pinned_item, id_note_status) VALUES (@id_note, @note, @image_filename, @note_time_created, @id_users, @id_label, @id_pinned_item, @id_note_status)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(insert, Connection))
                {
                    cmd.Parameters.AddWithValue("@id_note", note.IdNote);
                    cmd.Parameters.AddWithValue("@note", note.Note);
                    cmd.Parameters.AddWithValue("@image_filename", note.ImageFileName);
                    cmd.Parameters.AddWithValue("@note_time_created", note.NoteTimeCreated);
                    cmd.Parameters.AddWithValue("@id_users", note.IdUsers);
                    cmd.Parameters.AddWithValue("@id_label", note.IdLabels);
                    cmd.Parameters.AddWithValue("@id_pinned_item", note.IdPinnedItems);
                    cmd.Parameters.AddWithValue("@id_note_status", note.IdNoteStatus);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert fail! Error: " + ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool UpdateNote(Notes note)
        {
            try
            {
                Connection.Open();
                string update = @"UPDATE notes SET note = @note, image_filename = @image_filename, note_time_created = @note_time_created, id_users = @id_users, id_label = @id_label, id_pinned_item = @id_pinned_item, id_note_status = @id_note_status WHERE id_note = @id_note";
                using (NpgsqlCommand cmd = new NpgsqlCommand(update, Connection))
                {
                    cmd.Parameters.AddWithValue("@id_note", note.IdNote);
                    cmd.Parameters.AddWithValue("@note", note.Note);
                    cmd.Parameters.AddWithValue("@image_filename", note.ImageFileName);
                    cmd.Parameters.AddWithValue("@note_time_created", note.NoteTimeCreated);
                    cmd.Parameters.AddWithValue("@id_users", note.IdUsers);
                    cmd.Parameters.AddWithValue("@id_label", note.IdLabels);
                    cmd.Parameters.AddWithValue("@id_pinned_item", note.IdPinnedItems);
                    cmd.Parameters.AddWithValue("@id_note_status", note.IdNoteStatus);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("update fail! Error: " + ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool DeleteNote(int idNote)
        {
            try
            {
                Connection.Open();
                string insert = @"DELETE FROM notes WHERE id_note = @id_note";
                using (NpgsqlCommand cmd = new NpgsqlCommand(insert, Connection))
                {
                    cmd.Parameters.AddWithValue("@id_note", idNote);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete fail! Error: " + ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}