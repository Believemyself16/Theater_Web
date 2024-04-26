<template>
  <v-card>
    <v-card-title>LẤY LẠI MẬT KHẨU</v-card-title>
    <v-card-text>
      <v-form>
        <v-row>
          <v-col cols="12">
            <v-text-field
              type="email"
              label="Email"
              prepend-inner-icon="mdi-account"
              outlined
              dense
            ></v-text-field>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="6">CAPTCHA</v-col>
          <v-col cols="6">
            <v-text-field
              type="input"
              placeholder="Mã xác thực"
              outlined
              dense
            ></v-text-field>
          </v-col>
        </v-row>
      </v-form>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  name: "QuenMatKhau",
};
</script>
