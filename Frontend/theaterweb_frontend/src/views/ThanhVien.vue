<template>
  <v-container>
    <v-card>
      <v-tabs>
        <v-tab v-for="(item, index) in tabs" :key="index">
          {{ item.name }}
        </v-tab>
      </v-tabs>
    </v-card>
  </v-container>
</template>

<script>
export default {
  name: "ThanhVien",
  data() {
    return {
      tabs: [{ name: "ĐĂNG NHẬP" }, { name: "ĐĂNG KÍ" }],
    };
  },
};
</script>
